def sort_file(num):
    'Сортировка по столбцу'
    number = []
    with open('файлы\\Numbers_3.txt') as file:
        for line in file:
            number += map(int, line.split())    
    print(number)

def front_end():
    'Ввод номера столбца'
    num = input('Введите номер столбца: ')
    sort_file(num)

front_end()