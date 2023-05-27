namespace JobPortal.Data.Entities
{
    public class JobSkill
    {
        public int Id { get; set; }
        public Skill Skill { get; set; }
        public Job Job { get; set; }
    }
}
