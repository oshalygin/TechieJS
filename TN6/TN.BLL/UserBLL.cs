using TN.Models;

namespace TN.BLL
{
    public class UserBLL
    {

        public static UserDetailsViewModel UserProfile(CustomUser user)
        {

            UserDetailsViewModel uservm = new UserDetailsViewModel();

            uservm.UserName = user.UserName;

            uservm.State = user.State;
            uservm.FirstName = user.FirstName;
            uservm.LastName = user.LastName;
            uservm.Title = user.Title;


            if (user.Description == null)
            {
                uservm.Description =
                    "Please introduce yourself by with a brief description, your current projects, current profession, and at least one interesting fact!";
            }
            else
            {
                uservm.Description = user.Description;
            }

            if (user.Company == null || user.Company == "Not Listed")
            {
                uservm.Company = "Not Listed";
            }
                
            else
            {
                uservm.Company = user.Company;
            }

            if (user.Title == null || user.Title == "Web Designer")
            {
                uservm.Title = "Web Designer";
            }
            else
            {
                uservm.Title = user.Title;
            }

            uservm.PhotoPath = user.PhotoPath;

            return uservm;

        }


        

       

    }
}
