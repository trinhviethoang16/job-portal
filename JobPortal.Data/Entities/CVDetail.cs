namespace JobPortal.Data.Entities
{
    public class CVDetail
    {
        public int Id { get; set; }
        public int CVId { get; set; }
        public int SkillId { get; set; }
        public CV? CV { get; set; }
        public Skill? Skill { get; set; }
    }
}
