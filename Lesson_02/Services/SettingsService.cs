using System;
using Lesson_02.Common;

namespace Lesson_02.Services
{
    public class SettingsService : ISettingsService
    {
        public Language DefaultLanguage => Language.RU;
    }
}
