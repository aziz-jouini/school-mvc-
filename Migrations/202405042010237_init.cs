namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        courseID = c.Int(nullable: false, identity: true),
                        courseName = c.String(),
                        isAvaible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.courseID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        roomID = c.Int(nullable: false, identity: true),
                        roomName = c.String(),
                        roomSize = c.Int(nullable: false),
                        isAvaible = c.Boolean(nullable: false),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.roomID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentID = c.Int(nullable: false, identity: true),
                        studentName = c.String(),
                        studentNo = c.String(),
                    })
                .PrimaryKey(t => t.studentID);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        teacherID = c.Int(nullable: false, identity: true),
                        teacherName = c.String(),
                        teacherNo = c.String(),
                    })
                .PrimaryKey(t => t.teacherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Rooms");
            DropTable("dbo.Courses");
        }
    }
}
