using CVApplicationsManager.Contracts;
using CVApplicationsManager.Data;
using CVApplicationsManager.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CVApplicationsManager.Repositories
{
    public class CvApplicationsRepository : GenericRepository<CvApplicationModel>, ICvApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public CvApplicationsRepository(ApplicationDbContext context) : base(context)
        {
            this._context = context;
        }

        /// <summary>
        /// Method that Updates or Adds an entity with a file uploaded.
        /// Checks if the file to be uploaded is not empty. Then checks if the file is a pdf or word document, as only those are accepted.
        /// If an entity with the passed Id exists, the method perfoms an update. Else it creates a new entity in the database.
        /// Finally copies the uploaded file locally.
        /// </summary>
        /// <param name="file">The file that comes from a Create or Edit Form, if any.</param>
        /// <param name="application">The entity thats either going to be updated, or created.</param>
        /// <exception cref="Exception"> If the file is not a pdf or word doc an exception is thrown.</exception>
        public async Task UpdateOrCreateWithFile(IFormFile? file, CvApplicationModel application)
        {
            if (file is not null && file.Length > 0)
            {
                var fileType = file.ContentType; // get the format of the file.

                // check if file format is pdf or word.
                if (fileType is "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || fileType is "application/pdf")
                {
                    // get the file path and pass it to the database.
                    var fileName = file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", fileName);

                    // if the path doesnt exist -> create it -> assign it to application.CvBlob
                    // this approach needs admin rights for write.
                    //if (!Directory.Exists(filePath))
                    //{
                    //    Directory.CreateDirectory(filePath);
                    //    application.CvBlob = filePath;
                    //}
                    //else // just assign it to application.CvBlob
                    //{
                    //    application.CvBlob = filePath;
                    //}

                    application.CvBlob = filePath;

                    // if any entities exist with the  same Id, Update. Else Add.
                    if (await _context.CvApplications.AnyAsync(x => x.Id == application.Id))
                    {
                        await UpdateAsync(application);
                    }
                    else
                    {
                        await AddAsync(application);
                    }

                    // copy file to the specified path.
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    // Reaching here means the file is not a pdf or word doc.
                    throw new Exception("Uploaded files can only be of PDF or Word formats.");
                }
            }
        }
    }
}