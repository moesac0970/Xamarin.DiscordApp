using B4.EE.VanLookManu.Domain.Models;
using FreshMvvm;
using System;

namespace B4.EE.VanLookManu.ViewModels
{
    public class UserDetailViewModel : FreshBasePageModel
    {

        #region - Properties -

        private User CurrentUser;


        private string discriminator;
        public string Discriminator
        {
            get { return discriminator; }
            set
            {
                discriminator = value;
                RaisePropertyChanged(nameof(Discriminator));
            }
        }
        private bool isBot;
        public bool IsBot
        {
            get { return isBot; }
            set
            {
                isBot = value;
                RaisePropertyChanged(nameof(IsBot));
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }
        private DateTimeOffset createdAt;
        public DateTimeOffset CreatedAt
        {
            get { return createdAt; }
            set
            {
                createdAt = value;
                RaisePropertyChanged(nameof(CreatedAt));
            }
        }
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged(nameof(Id));
            }
        }


        private string activity;
        public string Activity
        {
            get { return activity; }
            set
            {
                activity = value;
                RaisePropertyChanged(nameof(Activity));
            }
        }

        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        #endregion

        #region - Overrides -
        public override void Init(object initData)
        {
            base.Init(initData);
            User user = new User();
            user = initData as User;
            Populate(user);
        }
        #endregion
        private void Populate(User user)
        {
            Status = user.Status.ToString();
            if(user.Activity == null)
            {
                Activity = "from api will not work with activity";
            }
            else
            {
                Activity = user.Activity.Name;
            }
            Id = user.Id.ToString();
            Username = user.Username;
            Discriminator = user.Discriminator;
            CreatedAt = user.CreatedAt;
            IsBot = user.IsBot;
        }
    }
}
