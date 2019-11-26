using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Connector;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using OnlineCafe.Api.Models;
using OnlineCafe.Api.Dialogs;

namespace OnlineCafe.Api.Controllers
{
  [Route("api/[controller]")]
  public class MessagesController : Controller
  {
    private readonly MicrosoftAppCredentials appCredentials;

    /// <summary>
    /// Initializes a new instance of the <see cref="MessagesController"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public MessagesController(IConfiguration configuration)
    {
      appCredentials = new MicrosoftAppCredentials(configuration);
    }

    // POST api/values
    [HttpPost, Authorize(Roles = "Bot")]
    public virtual async Task<OkResult> Post([FromBody]Activity activity)
    {
      if (activity.Type == ActivityTypes.Message)
      {
        await Conversation.SendAsync(activity, MakeLuisDialog);

      }
      else
      {
        await HandleSystemMessage(activity);
      }

      return Ok();
    }

    public static IDialog<Order> MakeLuisDialog()
    {
      return Chain.From(() => new LUISDialog(Order.BuildForm));
    }

    /// <summary>
    /// Handles the system message.
    /// </summary>
    /// <param name="activity">The activity.</param>
    private async Task<Activity> HandleSystemMessage(Activity message)
    {
      switch (message.Type)
      {
        case ActivityTypes.DeleteUserData:
          // Implement user deletion here
          // If we handle user deletion, return a real message
          break;

        case ActivityTypes.ConversationUpdate:
            IConversationUpdateActivity iConversationUpdated = message as IConversationUpdateActivity;
            if (iConversationUpdated != null)
            {
              ConnectorClient connector = new ConnectorClient(new System.Uri(message.ServiceUrl));

              foreach (var member in iConversationUpdated.MembersAdded ?? System.Array.Empty<ChannelAccount>())
              {
                // if the bot is added, then
                if (member.Id == iConversationUpdated.Recipient.Id)
                {
                  Activity replyToConversation = message.CreateReply("Hey there! How can we help you today?");
                  replyToConversation.Attachments = new List<Attachment>();

                  HeroCard card = new HeroCard
                  {
                    // title of the card  
                    Title = "Charlotte Cafe",
                    //subtitle of the card  
                    Subtitle = "Located in Charlotte (Obvio!)",
                    // navigate to page , while tab on card  
                    Tap = new CardAction(ActionTypes.OpenUrl, "Cafe Page", value: "https://microsoft.sharepoint.com/sites/refweb/NA/East/Charlotte/Pages/default.aspx"),
                    // list of buttons   
                    Buttons = new List<CardAction> {
                                    new CardAction(ActionTypes.PostBack, "Get me Coffee", value: "I want to order a coffee"),
                                    new CardAction(ActionTypes.PostBack, "Where is my Coffee", value: "Where is my coffee?"),
                                    new CardAction(ActionTypes.PostBack, "Show my favorites", value: "Show favorites") ,
                                    new CardAction(ActionTypes.PostBack, "Cancel my order", value: "Cancel Order")
                            }
                  };

                  replyToConversation.Attachments.Add(card.ToAttachment());

                  var reply = await connector.Conversations.SendToConversationAsync(replyToConversation);
                }
              }
            }
          break;

        case ActivityTypes.ContactRelationUpdate:
          // Handle add/remove from contact lists
          // Activity.From + Activity.Action represent what happened
          break;

        case ActivityTypes.Typing:
          // Handle knowing that the user is typing
          break;

        case ActivityTypes.Ping:
          await ReplyMessage(message, "Pong");
          break;

        default:
          break;
      }

      return null;
    }

    /// <summary>
    /// Replies the message.
    /// </summary>
    /// <param name="activity">The activity.</param>
    /// <param name="message">The message.</param>
    private async Task ReplyMessage(Activity activity, string message)
    {
      var serviceEndpointUri = new Uri(activity.ServiceUrl);
      var connector = new ConnectorClient(serviceEndpointUri, appCredentials);
      var reply = activity.CreateReply(message);

      await connector.Conversations.ReplyToActivityAsync(reply);
    }
  }
}
