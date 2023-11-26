using Domain.Command;
using MassTransit;

namespace Domain.Consumer
{
    public class OnboardingConfirmationHandler : IConsumer<OnboardingConfirmationEmailCommand>
    {
        public async Task Consume(ConsumeContext<OnboardingConfirmationEmailCommand> context)
        {
            OnboardingConfirmationEmailCommand command = context.Message;
            ///////////////////////
            // TODO: Email Sending
            // Logic will be
            // implemented later
            ///////////////////////
            await context.ConsumeCompleted;
        }
    }
}
