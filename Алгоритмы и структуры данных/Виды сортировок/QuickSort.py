def quick_sort(lst):
    '''Быстрая сортировка'''
    if len(lst) < 2: return lst
    pivot = lst[len(lst) // 2]
    left = []
    right = []
    middle = []
    for i in range(len(lst)):
        if lst[i] < pivot:
            left.append(lst[i])
        elif lst[i] > pivot:
            right.append(lst[i])
        else: 
            middle.append(lst[i])
    return quick_sort(left) + middle + quick_sort(right)
