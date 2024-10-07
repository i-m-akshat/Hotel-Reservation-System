using Backend.DTO.Admin;
using Backend.Models.Admin_Domain;

namespace Backend.Mappers
{
    public static class AdminMapper
    {
        public static Admin_DTO ToAdminDTO(this Admin admin)
        {
            return new Admin_DTO
            {
                FullName = admin.FullName
            };
        }
    }
}
