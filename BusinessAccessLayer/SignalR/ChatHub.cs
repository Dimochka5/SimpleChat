using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.Diagnostics;

namespace BusinessAccessLayer.SignalR
{
    public class ChatHub:Hub
    {
        public async Task JoinChat(int idChat,int idUser)
        {
            //TODO: check UsersInChat
            await Groups.AddToGroupAsync(idChat.ToString(), idUser.ToString());
        }
        public async Task LeaveChat(int idChat, int idUser)
        {
            //TODO:check UsersinChat
            await Groups.RemoveFromGroupAsync(idChat.ToString(), idUser.ToString());
        }
        public async Task SendMessage(int idChat,int idUser,string message)
        {
            //create message and check usersInChat
            await Clients.Group(idChat.ToString()).SendAsync(message);
        }
        public bool DeleteMessage(int idUser,int idMessage)
        {
            //check and delete
            return true;
        }
        public bool UpdateMessage(int  idChat,int idUser,string message)
        {
            //check and update
            return true;
        }
    }
}
