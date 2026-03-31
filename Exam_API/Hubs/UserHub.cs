using Microsoft.AspNetCore.SignalR;

namespace Exam_API.Hubs
{
    public class UserHub : Hub
    {
        private static int _totalViews { get; set; } = 0;

        public async Task OnPageLoad()
        {
            _totalViews++;

            await Clients.All.SendAsync("updateViews", _totalViews);
        }
    }
}
