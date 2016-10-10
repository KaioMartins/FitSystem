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
                        DiaDesc = c.Int(nullable: false),
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
                        Treino_TreinoId = c.Int(),
                        Treino_TreinoId1 = c.Int(),
                        Treino_TreinoId2 = c.Int(),
                        Treino_TreinoId3 = c.Int(),
                        Treino_TreinoId4 = c.Int(),
                    })
                .PrimaryKey(t => t.ExercicioTreinoId)
                .ForeignKey("dbo.Dias", t => t.DiaId, cascadeDelete: true)
                .ForeignKey("dbo.Exercicios", t => t.ExercicioId, cascadeDelete: true)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoId)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoId1)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoId2)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoId3)
                .ForeignKey("dbo.Treinoes", t => t.Treino_TreinoId4)
                .Index(t => t.DiaId)
                .Index(t => t.ExercicioId)
                .Index(t => t.Treino_TreinoId)
                .Index(t => t.Treino_TreinoId1)
                .Index(t => t.Treino_TreinoId2)
                .Index(t => t.Treino_TreinoId3)
                .Index(t => t.Treino_TreinoId4);
            
            CreateTable(
                "dbo.Treinoes",
                c => new
                    {
                        TreinoId = c.Int(nullable: false, identity: true),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.TreinoId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
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
            DropForeignKey("dbo.ExercicioTreinoes", "Treino_TreinoId4", "dbo.Treinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "Treino_TreinoId3", "dbo.Treinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "Treino_TreinoId2", "dbo.Treinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "Treino_TreinoId1", "dbo.Treinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "Treino_TreinoId", "dbo.Treinoes");
            DropForeignKey("dbo.ExercicioTreinoes", "ExercicioId", "dbo.Exercicios");
            DropForeignKey("dbo.ExercicioTreinoes", "DiaId", "dbo.Dias");
            DropForeignKey("dbo.Exercicios", "TipoExercicioId", "dbo.TipoExercicios");
            DropIndex("dbo.Treinoes", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "Treino_TreinoId4" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "Treino_TreinoId3" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "Treino_TreinoId2" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "Treino_TreinoId1" });
            DropIndex("dbo.ExercicioTreinoes", new[] { "Treino_TreinoId" });
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
