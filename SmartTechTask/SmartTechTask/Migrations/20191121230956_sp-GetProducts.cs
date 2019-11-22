using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartTechTask.Migrations
{
    public partial class spGetProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetProducts]  
(  
 @PageIndex INT,  
 @pageSize INT ,
 @search NVARCHAR(100)=''  
)   
AS  
 BEGIN  
 SELECT s.Id ,s.Name,s.Photo ,s.Price ,CONCAT(s.LastUpdated,' $') AS Price 
 FROM [dbo].[Product] s 

 WHERE s.Name like '%'+@search+'%'
 
 ORDER BY s.Id  OFFSET @PageSize*(@PageIndex-1) ROWS FETCH NEXT @PageSize ROWS ONLY;  
  
 SELECT COUNT(*) AS totalCount FROM [dbo].[Product]s WHERE  s.Name LIKE '%'+@search+'%';  
 END ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
