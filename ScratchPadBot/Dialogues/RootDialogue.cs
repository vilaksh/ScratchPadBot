using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using System.Threading;

namespace ScratchPadBot.Dialogues
{
    [Serializable]
    public class RootDialogue : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;
            await context.Forward(new ScratchQnA(), this.ResumeAfterScratchResponse, message, CancellationToken.None);
        }

        private async Task ResumeAfterScratchResponse(IDialogContext context, IAwaitable<object> result)
        {
            // Again, wait for the next message from the user.
            context.Wait(this.MessageReceivedAsync);
        }
    }
}