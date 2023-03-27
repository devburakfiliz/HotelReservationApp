using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        [Required(ErrorMessage = "Hizmet ID giriniz")]
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Hizmet ikon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Hizmet başlığı giriniz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Hizmet açıklaması giriniz")]
        [StringLength(500,ErrorMessage ="Hizmet açıklaması 500 karakterden fazla olamaz.")]
        public string Description { get; set; }
    }
}
