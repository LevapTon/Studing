## Задание

- вывести на экран список файлов из папки, в которой находится ваша программа (не включать вложенные директории и файлы из них)
- вывести на экран список файлов из папки, в которой находится ваша программа, отсортировав их по размеру по возрастанию
- предварительно (руками) сделайте в папке, в которой находится ваша программа, пару временных директорий и там создайте по 2-3 файла с расширением .ini
Задание для программы: найти все файлы в текущей папке (где лежит сама программа) и во всех её поддиректориях по фильтру: расширение файла .ini и поменять у таких файлов на расширение .cfg (самостоятельно найдите метод для переименования файлов)
- найти все файлы в папке, в которой находится ваша программа, и во всех её поддиректориях по фильтру: расширение файла .cfg и добавить последней строкой к содержимому каждого файла значение параметра - имя самого файла (без пути) по шаблону:
```
name_file: <имя файла>
```
Например, если был файл config.cfg и у него внутри были такие строчки:
```
date: 2022.03.31
list_avg: 1024.666
```
то после работы программы в этом файле будет следующее содержимое:
```
date: 2022.03.31
list_avg: 1024.666
name_file: config.cfg
```
В исходные файлы можете сами написать (придумать) какие-нибудь параметры (2-3 штуки)...
