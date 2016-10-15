namespace FitSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dias",
                c => new
                    {
                        DiaId = c.Int(nullable: false, identity: true),
                        DiaDesc = c.String(),
                    })
                .PrimaryKey(t => t.DiaId);
            
            CreateTable(
                "dbo.Exercicios",
                c => new
                    {
                        ExercicioId = c.Int(nullable: false, identity: true),
                        ExercicioDesc = c.String(),
                        TipoExercicioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExercicioId)
                .ForeignKey("dbo.TipoExercicios", t => t.TipoExercicioId, cascadeDelete: true)
                .Index(t => t.TipoExercicioId);
            
            CreateTable(
                "dbo.TipoExercicios",
                c => new
                    {
                        TipoExercicioId = c.Int(nullable: false, identity: true),
                        TipoExercicioDesc = c.String(),
                    })
                .PrimaryKey(t => t.TipoExercicioId);
            
            CreateTable(
                "dbo.ExercicioTreinoes",
                c => new
                    {
                        ExercicioTreinoId = c.Int(nullable: false, identity: true),
                        Repeticao = c.Int(nullable: false),
                        Serie = c.Int(nullable: false),
                        DiaId = c.Int(nullable: false),
                        ExercicioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExercicioTreinoId)
                .ForeignKey("dbo.Dias", t => t.DiaId, cascadeDelete: true)
                .ForeignKey("dbo.Exercicios", t => t.ExercicioId, cascadeDelete: true)
                .Index(t => t.DiaId)
                .Index(t => t.ExercicioId);
            
            CreateTable(
                "dbo.Treinoes",
                c => new
                    {
                        TreinoId = c.Int(nullable: false, identity: true),
                        ExercicioTreinoId = c.Int(nullable: false),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.TreinoId)
                .ForeignKey("dbo.ExercicioTreinoes", t => t.ExercicioTreinoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.ExercicioTreinoId)
                .Index(t => t.Usuario_UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Idade = c.Int(nullable: false),
                        Peso = c.Double(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treinoes", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Treinoes", "ExercicioTreinoId", "dbo.ExercicioTreinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "ExercicioId", "dbo.Exercicios");
            DropForeignKey("dbo.ExercicioTreinoes", "DiaId", "dbo.Dias");
            DropForeignKey("dbo.Exercicios", "TipoExercicioId", "dbo.TipoExercicios");
            DropIndex("dbo.Treinoes", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.Treinoes", new[] { "ExercicioTreinoId" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "ExercicioId" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "DiaId" });
            DropIndex("dbo.Exercicios", new[] { "TipoExercicioId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Treinoes");
            DropTable("dbo.ExercicioTreinoes");
            DropTable("dbo.TipoExercicios");
            DropTable("dbo.Exercicios");
            DropTable("dbo.Dias");
        }
    }
}
