namespace AdministradorCafeteriaVirtual.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeramigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(),
                        name = c.String(),
                        description = c.String(),
                        enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Pregunta",
                c => new
                    {
                        idPregunta = c.Int(nullable: false, identity: true),
                        idCategoria = c.Int(nullable: false),
                        idusuario = c.Int(nullable: false),
                        contenido = c.String(),
                        open = c.Boolean(nullable: false),
                        enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.idPregunta)
                .ForeignKey("dbo.Category", t => t.idCategoria, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.idusuario, cascadeDelete: false)
                .Index(t => t.idCategoria)
                .Index(t => t.idusuario);
            
            CreateTable(
                "dbo.Respuesta",
                c => new
                    {
                        idrespuesta = c.Int(nullable: false, identity: true),
                        contenido = c.String(),
                        idusuario = c.Int(nullable: false),
                        bestAnswer = c.Boolean(nullable: false),
                        enable = c.Boolean(nullable: false),
                        idpregunta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idrespuesta)
                .ForeignKey("dbo.Pregunta", t => t.idpregunta, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.idusuario, cascadeDelete: false)
                .Index(t => t.idusuario)
                .Index(t => t.idpregunta);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                        username = c.String(),
                        password = c.String(),
                        enable = c.Boolean(nullable: false),
                        firstlog = c.DateTime(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        idsession = c.Int(nullable: false, identity: true),
                        userid = c.Int(nullable: false),
                        logDate = c.DateTime(),
                        ip = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.idsession)
                .ForeignKey("dbo.User", t => t.userid, cascadeDelete: false)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.ChatMessage",
                c => new
                    {
                        idMessage = c.Int(nullable: false, identity: true),
                        idUser = c.Int(nullable: false),
                        date = c.DateTime(),
                        message = c.String(),
                    })
                .PrimaryKey(t => t.idMessage)
                .ForeignKey("dbo.User", t => t.idUser, cascadeDelete: false)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.UserRoom",
                c => new
                    {
                        idRoom = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        connected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.idRoom, t.idUser })
                .ForeignKey("dbo.Room", t => t.idRoom, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.idUser, cascadeDelete: false)
                .Index(t => t.idRoom)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.PrivateMessage",
                c => new
                    {
                        idRoom = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                        idmessage = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        date = c.DateTime(),
                        
                    })
                .PrimaryKey(t => t.idmessage)
                .ForeignKey("dbo.UserRoom", t => new { t.idRoom, t.idUser }, cascadeDelete: false)
                .Index(t => new { t.idRoom, t.idUser });
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        idroom = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        enable = c.Boolean(nullable: false),
                        sits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idroom);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pregunta", "idusuario", "dbo.User");
            DropForeignKey("dbo.Respuesta", "idusuario", "dbo.User");
            DropForeignKey("dbo.UserRoom", "idUser", "dbo.User");
            DropForeignKey("dbo.UserRoom", "idRoom", "dbo.Room");
            DropForeignKey("dbo.PrivateMessage", new[] { "idRoom", "idUser" }, "dbo.UserRoom");
            DropForeignKey("dbo.ChatMessage", "idUser", "dbo.User");
            DropForeignKey("dbo.Login", "userid", "dbo.User");
            DropForeignKey("dbo.Respuesta", "idpregunta", "dbo.Pregunta");
            DropForeignKey("dbo.Pregunta", "idCategoria", "dbo.Category");
            DropIndex("dbo.PrivateMessage", new[] { "idRoom", "idUser" });
            DropIndex("dbo.UserRoom", new[] { "idUser" });
            DropIndex("dbo.UserRoom", new[] { "idRoom" });
            DropIndex("dbo.ChatMessage", new[] { "idUser" });
            DropIndex("dbo.Login", new[] { "userid" });
            DropIndex("dbo.Respuesta", new[] { "idpregunta" });
            DropIndex("dbo.Respuesta", new[] { "idusuario" });
            DropIndex("dbo.Pregunta", new[] { "idusuario" });
            DropIndex("dbo.Pregunta", new[] { "idCategoria" });
            DropTable("dbo.Room");
            DropTable("dbo.PrivateMessage");
            DropTable("dbo.UserRoom");
            DropTable("dbo.ChatMessage");
            DropTable("dbo.Login");
            DropTable("dbo.User");
            DropTable("dbo.Respuesta");
            DropTable("dbo.Pregunta");
            DropTable("dbo.Category");
        }
    }
}
