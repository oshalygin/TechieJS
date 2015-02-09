using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace TN.BLL.Utility
{
    public class ImageUtility
    {
        private const string ProfileImageDatabasePath = "~/Content/img/UserPhotos/";

        private const string BlogImageDatabasePath = "~/Content/img/BlogImages/";

        private const string PublicImageDatabasePath = "~/Content/img/PublicImages/";


        public static string FullImagePath(string profileFileName, ImagePath path)
        {

            if (path == ImagePath.ProfileImage)
            {
                return Path.Combine(HttpContext.Current.Server.MapPath(ProfileImageDatabasePath), profileFileName);
            }

            if (path == ImagePath.BlogPostImage)
            {
                return Path.Combine(HttpContext.Current.Server.MapPath(BlogImageDatabasePath), profileFileName);
            }

            if (path == ImagePath.PublicImage)
            {
                return Path.Combine(HttpContext.Current.Server.MapPath(PublicImageDatabasePath), profileFileName);
            }

            return null;

            //TODO: So far this will only work on .jpg files, need to modify this to accept all image types.
        }


        public static string UpdatePhoto(HttpPostedFileBase file, ImagePath path)
        {

            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);

                string photoUrl = Guid.NewGuid().ToString();
                string photoUrlOriginal = photoUrl + "_original" + fileExtension;

                string returnUrl = photoUrl + ".png";

                string serverPath = FullImagePath(photoUrlOriginal, path);
                file.SaveAs(serverPath);

                //Resizes the pic without changing the properties of the original pic which has _or in the filename





                //Returning back to the controller...
                //Using Substring to remove the "~" from the path so that the database call can be clean in the Razor View.
                if (path == ImagePath.ProfileImage)
                {
                    ResizeStream(256, 256, file.InputStream, FullImagePath((photoUrl + ".png"), path));
                    return ProfileImageDatabasePath.Substring(1) + returnUrl;
                }
                if (path == ImagePath.BlogPostImage)
                {
                    ResizeStream(848, 307, file.InputStream, FullImagePath((photoUrl + ".png"), path));
                    return BlogImageDatabasePath.Substring(1) + returnUrl;

                }

                if (path == ImagePath.PublicImage)
                {
                
                    //Return the original saved image path with ending "_original"
                    return PublicImageDatabasePath.Substring(1) + photoUrlOriginal;

                }

                return null;


            }
            return null;

        }

        public static bool FileExtensionAccepted(string extension)
        {
            if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp" || extension == ".png")
            {
                return true;
            }

            return false;
        }

        private static void ResizeStream(int imageWidth, int imageHeight, Stream filePath, string outputPath)
        {

            Image image = Image.FromStream(filePath);
            Bitmap thumbnailBitmap = new Bitmap(imageWidth, imageHeight);
            Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            Rectangle imageRectangle = new Rectangle(0, 0, imageWidth, imageHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

            //Saves the new file as ".jpeg" format
            thumbnailBitmap.Save(outputPath, ImageFormat.Png);
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();

        }

    }
}
