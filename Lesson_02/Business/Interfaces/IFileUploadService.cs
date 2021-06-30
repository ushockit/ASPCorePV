using System;
namespace Lesson_02.Business.Interfaces
{
    public interface IUploadService
    {
        void Upload();
        string GetUploadInfo(string filename);
    }
}
