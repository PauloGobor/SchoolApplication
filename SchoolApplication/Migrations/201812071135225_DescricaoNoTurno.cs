namespace SchoolApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescricaoNoTurno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Turnos", "Descricao", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Turnos", "Descricao");
        }
    }
}
