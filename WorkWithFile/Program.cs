using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Показать информацию о дисках");
            Console.WriteLine("2. Управление каталогами");
            Console.WriteLine("3. Управление файлами");
            Console.WriteLine("0. Выход");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowDriveInfo();
                    break;
                case "2":
                    ManageDirectories();
                    break;
                case "3":
                    ManageFiles();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу, чтобы продолжить.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ShowDriveInfo()
    {
        Console.Clear();
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (var drive in drives)
        {
            Console.WriteLine($"Диск: {drive.Name}");
            if (drive.IsReady)
            {
                Console.WriteLine($"  Метка тома: {drive.VolumeLabel}");
                Console.WriteLine($"  Тип файловой системы: {drive.DriveFormat}");
                Console.WriteLine($"  Общий размер: {drive.TotalSize} байт");
                Console.WriteLine($"  Доступное место: {drive.AvailableFreeSpace} байт");
            }
            else
            {
                Console.WriteLine("  Диск не готов.");
            }
        }
        Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню.");
        Console.ReadKey();
    }

    static void ManageDirectories()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Управление каталогами:");
            Console.WriteLine("1. Создать каталог");
            Console.WriteLine("2. Удалить каталог");
            Console.WriteLine("3. Показать содержимое каталога");
            Console.WriteLine("4. Показать свойства каталога");
            Console.WriteLine("0. Назад");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите путь для нового каталога: ");
                    string newDirPath = Console.ReadLine();
                    Directory.CreateDirectory(newDirPath);
                    Console.WriteLine("Каталог создан. Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Введите путь для удаления каталога: ");
                    string delDirPath = Console.ReadLine();
                    if (Directory.Exists(delDirPath))
                    {
                        Directory.Delete(delDirPath, true);
                        Console.WriteLine("Каталог удалён. Нажмите любую клавишу для продолжения.");
                    }
                    else
                    {
                        Console.WriteLine("Каталог не существует. Нажмите любую клавишу для продолжения.");
                    }
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Введите путь к каталогу: ");
                    string dirPath = Console.ReadLine();
                    if (Directory.Exists(dirPath))
                    {
                        string[] entries = Directory.GetFileSystemEntries(dirPath);
                        Console.WriteLine("Содержимое каталога:");
                        foreach (string entry in entries)
                        {
                            Console.WriteLine(entry);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Каталог не существует.");
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Write("Введите путь к каталогу: ");
                    string dirInfoPath = Console.ReadLine();
                    if (Directory.Exists(dirInfoPath))
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(dirInfoPath);
                        Console.WriteLine($"Полный путь: {dirInfo.FullName}");
                        Console.WriteLine($"Дата создания: {dirInfo.CreationTime}");
                        Console.WriteLine($"Время последнего изменения: {dirInfo.LastWriteTime}");
                    }
                    else
                    {
                        Console.WriteLine("Каталог не существует.");
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ManageFiles()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Управление файлами:");
            Console.WriteLine("1. Создать файл и записать текст");
            Console.WriteLine("2. Прочитать содержимое файла");
            Console.WriteLine("3. Переименовать файл");
            Console.WriteLine("4. Удалить файл");
            Console.WriteLine("5. Показать свойства файла");
            Console.WriteLine("0. Назад");
            Console.Write("Ваш выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите путь для нового файла: ");
                    string newFilePath = Console.ReadLine();
                    Console.Write("Введите текст для записи в файл: ");
                    string content = Console.ReadLine();
                    File.WriteAllText(newFilePath, content);
                    Console.WriteLine("Файл создан и текст записан. Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Write("Введите путь к файлу: ");
                    string readFilePath = Console.ReadLine();
                    if (File.Exists(readFilePath))
                    {
                        string fileContent = File.ReadAllText(readFilePath);
                        Console.WriteLine("Содержимое файла:");
                        Console.WriteLine(fileContent);
                    }
                    else
                    {
                        Console.WriteLine("Файл не существует.");
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Write("Введите путь к файлу: ");
                    string oldFilePath = Console.ReadLine();
                    if (File.Exists(oldFilePath))
                    {
                        Console.Write("Введите новое имя файла: ");
                        string newFileName = Console.ReadLine();
                        string newFilePathRename = Path.Combine(Path.GetDirectoryName(oldFilePath), newFileName);
                        File.Move(oldFilePath, newFilePathRename);
                        Console.WriteLine("Файл переименован. Нажмите любую клавишу для продолжения.");
                    }
                    else
                    {
                        Console.WriteLine("Файл не существует.");
                    }
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Write("Введите путь к файлу: ");
                    string deleteFilePath = Console.ReadLine();
                    if (File.Exists(deleteFilePath))
                    {
                        File.Delete(deleteFilePath);
                        Console.WriteLine("Файл удалён. Нажмите любую клавишу для продолжения.");
                    }
                    else
                    {
                        Console.WriteLine("Файл не существует.");
                    }
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Write("Введите путь к файлу: ");
                    string fileInfoPath = Console.ReadLine();
                    if (File.Exists(fileInfoPath))
                    {
                        FileInfo fileInfo = new FileInfo(fileInfoPath);
                        Console.WriteLine($"Имя: {fileInfo.Name}");
                        Console.WriteLine($"Полный путь: {fileInfo.FullName}");
                        Console.WriteLine($"Размер: {fileInfo.Length} байт");
                        Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
                    }
                    else
                    {
                        Console.WriteLine("Файл не существует.");
                    }
                    Console.WriteLine("Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
