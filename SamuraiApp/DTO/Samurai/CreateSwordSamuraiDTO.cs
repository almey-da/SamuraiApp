namespace SamuraiApp.DTO.Samurai
{
    public class CreateSwordSamuraiDTO
    {
        //untuk inject sword tanpa samurai ID
        public string SwordName { get; set; }
        public int Year { get; set; }
        public int Weight { get; set; }
    }
}
