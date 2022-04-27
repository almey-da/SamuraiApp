namespace SamuraiApp.DTO.Samurai
{
    public class CreateSamuraiWithSwordDTO
    {
        public string SamuraiName { get; set; }
        public List<CreateSwordSamuraiDTO> Swords { get; set; } //menampilkan yang tanpa samurai id
    }
}
