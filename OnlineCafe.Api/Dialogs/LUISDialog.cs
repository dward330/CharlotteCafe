using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineCafe.Api.Models;


namespace OnlineCafe.Api.Dialogs
{
  [LuisModel("eb9a9b07-eff8-4bfe-b05c-98f720278a0f", "fbecab69a915414d87fb9a568525976f", Staging = true)]
  [Serializable]
  public class LUISDialog : LuisDialog<Order>
  {

    private readonly BuildFormDelegate<Order> NewOrder;

    public LUISDialog(BuildFormDelegate<Order> newOrder)
    {
      this.NewOrder = newOrder;
    }

    [LuisIntent("")]
    public async Task None(IDialogContext context, LuisResult result)
    {
      await context.PostAsync("Sorry I am just a bot. I didn't understand what you said");
      context.Wait(MessageReceived);
    }

    [LuisIntent("GreetingIntent")]
    public async Task Greeting(IDialogContext context, LuisResult result)
    {
      //context.Call(new GreetingDialog(), Callback);
      await context.PostAsync("Hi Amy! How can I help you today?");
      context.Wait(MessageReceived);
    }

    private async Task Callback(IDialogContext context, IAwaitable<object> result)
    {
      context.Wait(MessageReceived);
    }

    [LuisIntent("NewOrderIntent")]
    public async Task NewDrinkOrder(IDialogContext context, LuisResult result)
    {
      var enrollmentForm = new FormDialog<Order>(new Order(), this.NewOrder, FormOptions.PromptInStart);

      context.Call<Order>(enrollmentForm, AfterNewOrder);
    }

    [LuisIntent("ConfirmOrderIntent")]

    public async Task ConfirmOrder(IDialogContext context, LuisResult result)
    {
      await context.PostAsync("Your order is received! Pay for it at the cafe counter");

    }
    private async static Task<IDialog<string>> AfterNewOrder(IBotContext context, IAwaitable<object> item)
    {
      await context.PostAsync("Your order is received! Pay for it at the cafe counter");
      return null;
    }

    [LuisIntent("OrderStatusIntent")]
    public async Task OrderStatus(IDialogContext context, LuisResult result)
    {
      await context.PostAsync("Its ready. Go pick it up at the counter");
      context.Wait(MessageReceived);
    }

    [LuisIntent("ShowFavoriteIntent")]
    public async Task ShowFavourites(IDialogContext context, LuisResult result)
    {
      HeroCard card = new HeroCard
      {
        // title of the card  
        Title = "You said you love them! Select to order",
        Buttons = new List<CardAction> {
                                    new CardAction(ActionTypes.PostBack, "Cappucino, Medium, Extra cream", value: "Cappucino, Medium, Extra cream"),
                                    new CardAction(ActionTypes.PostBack, "Iced Coffee, Large, Extra strong", value: "Iced Coffee, Large, Extra strong")

                            }
      };

      var reply = ((Activity)context.Activity).CreateReply(string.Empty);
      reply.Attachments = new List<Attachment>();
      reply.Attachments.Add(card.ToAttachment());

      await context.PostAsync(reply);
      context.Wait(MessageReceived);
    }

    [LuisIntent("OrderFavoritesIntent")]
    public async Task OrderFavorite(IDialogContext context, LuisResult result)
    {
      var selectedFavorite = result.Query.ToString();
      await context.PostAsync(string.Format("{0}. Is that your order?", selectedFavorite));

      await ConfirmOrder(context);
      context.Wait(MessageReceived);
    }

    private async Task ConfirmOrder(IDialogContext context)
    {
      HeroCard card = new HeroCard
      {
        // title of the card  
        Title = "Confirm Order",
        Buttons = new List<CardAction> {
                                    new CardAction(ActionTypes.PostBack, "Confirm my order", value: "Confirm my order"),
                                    new CardAction(ActionTypes.PostBack, "Noooo thats not what I want", value: "main menu")
                            }
      };

      var reply = ((Activity)context.Activity).CreateReply(string.Empty);
      reply.Attachments = new List<Attachment>();
      reply.Attachments.Add(card.ToAttachment());

      await context.PostAsync(reply);
      //context.Wait(MessageReceived);
    }

    [LuisIntent("MainMenuIntent")]
    private async Task MainMenu(IDialogContext context, LuisResult result)
    {
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
                                    new CardAction(ActionTypes.PostBack, "Where is my Coffee?", value: "Where is my coffee?"),
                                    new CardAction(ActionTypes.PostBack, "Show my favorites", value: "Show my favorites") ,
                                    new CardAction(ActionTypes.PostBack, "Cancel my order", value: "Cancel Order")
                            }
      };

      var reply = ((Activity)context.Activity).CreateReply(string.Empty);
      reply.Attachments = new List<Attachment>();
      reply.Attachments.Add(card.ToAttachment());

      await context.PostAsync(reply);
    }

  }

}
