using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System.Web.Configuration;

namespace ScratchPadBot.Dialogues
{
    [Serializable]
    public class ScratchQnA : QnAMakerDialog
    {
        public ScratchQnA() : base(new QnAMakerService(new QnAMakerAttribute(
                WebConfigurationManager.AppSettings["KnowledgeBaseKey"],
                WebConfigurationManager.AppSettings["KnowledgeBaseId"],
                "Question/Pharse not found in QA DB.")))
        { }

        protected override async Task DefaultWaitNextMessageAsync(IDialogContext context, IMessageActivity message, QnAMakerResults results)
        {
            if (results.Answers.Count == 0)
            {
                // logic to learn answers.
            }

            await base.DefaultWaitNextMessageAsync(context, message, results);
        }
    }
}