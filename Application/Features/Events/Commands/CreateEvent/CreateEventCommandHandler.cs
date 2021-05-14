using Application.Contract.Infrastructure;
using Application.Contract.Persistance;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contract.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler: IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateEventCommandHandler(IMapper mapper,IEventRepository eventRepository,IEmailService emailService)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _emailService = emailService;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (validatorResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validatorResult);

            var @event = _mapper.Map<Event>(request);

            @event = await _eventRepository.AddAsync(@event);

            var email = new Email() { To = "ilknur.aspir2501@gmail.com", Body = $"Event created: {request}", Subject = "Event" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
            }
            return @event.EventId;
        }
    }
}
