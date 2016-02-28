using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    static public class Translations
    {
        static public string[] lang_en = {
             // this is of console, message boxes and elements of main window
/*0-3*/      "shown", "hidden","saved", "not saved",
/*4-8*/      "Settings", "Console", "Main window", "Configs window","Tray icon",
/*9-11*/     "Program started","initialized","Last Screenshot ",
/*12-15*/    " not exist", "Screenshot taken", "Playing sound","Path set, ",
/*16-19*/    "Saving path to last path","Current path","Writing current path to pathLabel", "Path Selection Dialog was closed or cancelled",
/*20-22*/    "Name for Screenshot created, name = ","saved as","Showing lstButton",
/*23-25*/    "Showing Path Selection Dialog", "Configs window alredy opened", "closed", 
/*26-28*/    "Hotkey catched with m.LParam of Key = ", "and m.LParam of Modifier = ","Detected another instance of ScreenShotter is being opened, it was closed",
/*29-33*/    "Main Window is visible, getting it to top", "Caution!","Select folder","Open last screenshot","Root folder of the program",
             // this is configs window & selection screenshot messagebox 
/*34-36*/    "Display Console Button in Main Window", "Display Tray Icon Show//Hide Button in Main Window","Display Tooltips when hover elements in Main Window",
/*37-43*/    "Closing will end program?","Language","JPG Quality:","Saving format:","Cancel","Default","Too small selection",
/*44-45*/    "Instantly changed language to ", "Console",
             // this is tooltips of the main window
/*46*/       "ALT + F3 to make a Screenshot\nCTRL + F3 to make Screenshot of active window\nCTRL + SHIFT + F3 to make Selection Screenshot(ESC or ALT+F4 to cancel)\nALT + CTRL + F3 to Show/Hide Main Window\nALT + SHIFT + F3 to open last Screenshot\nALT + WIN + CTRL + F4 to immediately Shutdown.",
/*47-49*/    "Click here to show/hide Tray Icon.","Click here to select Path where to save Screenshots.","Click here to open last Screenshot.",
/*50-52*/    "Click here to show/hide Console.","Click here to open configs window.","Here shown current path for saving screenshots.\nPath:",
             // this is tooltips of the configs window
/*53*/       "While this disabled closing Main Window will not end program\nto close program hit \"Exit\" in Tray Menu or CTRL + WIN + ALT + F4",
/*54-55*/    "Displays tooltips like this one in main window, when hovering something.", "If this checked \"show/hide tray button\" will be visible in main window.",
/*56-58*/    "Enabling this will show the \"console show/hide button\" in main window.","Select screenshots saving format.","This is language select panel.",
             // this is tray menu and About window
/*59-64*/    "Configs","Show/Hide","About","Exit","Version","With this program you can do screenshots.","For more info hover the \"?\" in main window.",
             // this is message box in configs
/*65-67*/    "I must be a number!\nNumber must be from 0 to 100","Error!",
             // Startup icon tooltip
/*67-68*/    "Hey!","I'm here, click here!"
                                         };
        static public string[] lang_ru = {
             // Это консоли, сообщений и элементов главного окна
/*0-3*/      "показан", "скрыт","сохранены", "не сохранены",
/*4-8*/      "Настройки", "Консоль", "Главное окно", "Окно настроек","Иконка трея",
/*9-11*/     "Программа запущена","инициализирована","Последний скриншот ",
/*12-15*/    " не существует", "Скриншот взят", "Играю звук","Путь утановлен, ",
/*16-19*/    "Сохраняю путь в последний путь","Текущий путь","Пишу текущий путь в pathLabel", "Диалог Выбора Пути был закрыт или отменен",
/*20-22*/    "Имя для скриншота создано, имя = ","сохранен как ","Показываю lstButton",
/*23-25*/    "Показываю Диалог Выбора Пути", "Окно настроек уже открыто", "закрыт",
/*26-28*/    "Поймана горячая клавиша с m.LParam клавиши = ", "и m.LParam модификатора = ","Обнаружена еще одна копия ScreenShotter которая собиралась открыться, она была закрыта",
/*29-33*/    "Главное окно видно, активирую его", "Внимание!","Выбор папки","Открыть последний скриншот","Корневая папка программы",
             // Это окна настроек, и всплывающих окон 
/*34-36*/    "Отображать кнопку консоли", "Отображать кнопку переключения трей иконки","Отображать подсказки",
/*37-43*/    "Закрытие закроет программу?","Язык","JPG Качество:","Формат сохранения:","Отмена","Стандарт","Слишком маленькое выделение",
/*44-45*/    "Мнговенно изменен язык на ", "Консоль",
             // Это подсказок в главном окне
/*46*/       "ALT + F3 для взятия скриншота\nCTRL + F3 для взятия скриншота активного окна\nCTRL + SHIFT + F3 скриншот выделения(ESC или ALT+F4 чтобы отменить)\nALT + CTRL + F3 чтобы показать/скрыть главное окно\nALT + SHIFT + F3 чтобы открыть последний скриншот\nALT + WIN + CTRL + F4 сразу выйти из программы.",
/*47-49*/    "Нажмите здесь для показа/скрытия иконки трея.","Нажмите здесь для выбора Пути для сохранения скриншотов.","Нажмите здесь для открытия последнего скриншота.",
/*50-52*/    "Нажмите здесь для показа/скрытия консоли.","Нажмите здесь для открытия настроек.","Здесь показан путь сохранения скриншотов.\nПуть:",
             // Это подсказки окна настроек
/*53*/       "Пока это выключено закрытие главного окна не завершит программу\nчтобы завершить програму нажмите \"Выход\" в меню трей иконки или CTRL + WIN + ALT + F4",
/*54-55*/    "Отображает подсказки как эта, в главном окне, когда наводите на что-то.", "Если включено то \"кнопка показа/скрытия трей иконки\" будет видна в главном окне.",
/*56-58*/    "Если включено то \"кнопка показа/скрытия консоли иконки\" будет видна в главном окне.","Выберите формат сохранения скриншотов.","Это панель выбора языка.",
             // Это меню в трее и окно О программе
/*59-64*/    "Настройки","Показать/Скрыть","О...","Выход","Версия","С помощью этой программы можно делать снимки экрана(скриншоты).", "Для большей информации наведите мышь на \"?\" в главном окне.",
             // Окно сообщения в меню настроек
/*65-66*/    "Это должно быть число!\nЧисло должно быть от 0 до 100","Ошибка!",
             // Всплывающая подсказка при первом запуске
/*67-68*/    "Эй!","Я здесь, щелкни здесь!"
                                    };
       
    }
}
