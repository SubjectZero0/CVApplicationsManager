using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CVApplicationsManager.Repositories
{
    public class CvApplicationsRepository : GenericRepository<CvApplicationModel>, ICvApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public CvApplicationsRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<bool> UploadFileEditAsync(IFormFile? file, CvApplicationModel application)
        {
            if (file != null && file.Length > 0)
            {

                var fileType = file.ContentType; // get the format of the file

                // check if file format is pdf or word
                if (fileType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || fileType == "application/pdf")
                {
                    var fileName = file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", fileName);
                    application.CvBlob = filePath;
                
                    await UpdateAsync(application);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return true;
                }

                // if other than pdf or word...
                throw new Exception("Uploaded files can only be of PDF or Word formats.");

            }

            return false;
        }
    }
}