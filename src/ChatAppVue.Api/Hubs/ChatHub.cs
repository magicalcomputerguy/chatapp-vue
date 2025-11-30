using Microsoft.AspNetCore.SignalR;

namespace ChatAppVue.Api.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string groupId, string message)
    {
        // Broadcast message to all connected clients to specified group
        await Clients.Group(groupId).SendAsync("ReceiveMessage", user, message);
    }

    public async Task GetGroupMessages(string groupId)
    {
        // When they open a group chat
        throw new NotImplementedException();
    }

    public async Task AcknowledgeGroupMessages(string groupId)
    {
        // When they read all messages in a group
        throw new NotImplementedException();
    }
}
