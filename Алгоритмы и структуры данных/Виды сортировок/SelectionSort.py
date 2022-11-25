def selection_sort(lst):
    '''Сортировка выбором'''
    for i in range(len(lst)):
        min = lst[i]
        index = i
        for j in range(i + 1, len(lst)):
            if (lst[j] < min):
                min = lst[j]
                index = j
        lst[i], lst[index] = lst[index], lst[i]
