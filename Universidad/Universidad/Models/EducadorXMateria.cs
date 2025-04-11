namespace Universidad.Models
{
    public class EducadorXMateria
    {
        public int Id_Educador { get; set; }
        public Educador Educador { get; set; }

        public int Id_Materia { get; set; }
        public Materia Materia { get; set; }
    }
}