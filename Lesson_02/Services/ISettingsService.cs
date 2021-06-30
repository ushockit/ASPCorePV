using System;
using Lesson_02.Common;

namespace Lesson_02.Services
{
    public interface ISettingsService
    {
        Language DefaultLanguage { get; }
    }
}
