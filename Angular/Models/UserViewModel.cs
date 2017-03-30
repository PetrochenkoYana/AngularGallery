using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Angular.Models
{
    public enum Role
    {
        Administrator = 1,
        User    
    }
    
    public class UserViewModel
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [Display(Name = "Enter your e-mail")]
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$", ErrorMessage = "Please enter valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        public string ConfirmPassword { get; set; }

        public string PersonalInformation { get; set; }

        [Required]
        [Display(Name = "Enter the code from the image")]
        public string Captcha { get; set; }

        public string AccountImage { get; set; }

        public Role Role { get; set; }
    }

    public class AlbumViewModel
    {
        public int AlbumId { get; set; }

        [Display(Name = "Album name")]
        public string Name { get; set; }

        public string AlbumImage { get; set; }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }
    }

    public class PhotoViewModel
    {
        public int PhotoId { get; set; }
        [Display(Name = "Photo name")]
        public string Name { get; set; }

        public string Path { get; set; }

        public int AlbumId { get; set; }

        public AlbumViewModel Album { get; set; }

        public DateTime LoadDateTime { get; set; }

        public int LikesAmount { get; set; }
    }

    public class UserAlbumModel
    {
        public UserViewModel User { get; set; }
        public IEnumerable<AlbumViewModel> Album { get; set; }

        public UserAlbumModel(UserViewModel user,IEnumerable<AlbumViewModel> album)
        {
            this.User = user;
            this.Album = album;
        }
    }

    public class AlbumPhotoModel
    {
        public AlbumViewModel Album { get; set; }
        public IEnumerable<PhotoViewModel> Photos { get; set; }

        public AlbumPhotoModel(AlbumViewModel album, IEnumerable<PhotoViewModel> photos)
        {
            this.Album = album;
            this.Photos = photos;
        }
    }

    public class LikeViewModel
    {
        public int LikeId { get; set; }
        
        public int UserId { get; set; }

        public int PhotoId { get; set; }
    }

}