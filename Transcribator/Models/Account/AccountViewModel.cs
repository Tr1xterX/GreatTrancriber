using System.ComponentModel.DataAnnotations;

namespace Transcribator.Mvc.Models.Account
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }

        public RegisterViewModel RegisterViewModel { get; set; }
    }

    //отдельная модель для каждого частичного представления на стр регистрации/авторизации
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно")] //обязательные атрибуты для валидации
        public string Login { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Данное поле обязательно")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Данное поле обязательно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")] //ограничения равенства, чтобы пароли совпадали
        public string RepeatPassword { get; set; }
    }
}
