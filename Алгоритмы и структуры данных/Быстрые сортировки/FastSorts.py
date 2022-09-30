'''
сортировки слиянием, быстрая, пирамидальная
'''


def merge(a, b):
    '''
    функция слияния двух отсортированных списков
    возвращает общий отсортированный список
    переписать функцию без рекурсии
    циклом, сложность равна n
    '''
    if a == [] or b == []: return a + b
    if a[0] < b[0]:
        return [a[0]] + merge(a[1:], b)
    else:
        return [b[0]] + merge(a, b[1:])


def merge_fix(a, b):
    '''
    исправленная функция
    '''
    index_a = 0
    index_b = 0
    res = []
    for _ in range(len(a) + len(b)):
        if index_a + 1 > len(a):
            res += [b[index_b]]
            break
        elif index_b + 1 > len(b):
            res += [a[index_a]]
            break
        if a[index_a] < b[index_b]:
            res += [a[index_a]]
            index_a += 1
        else:
            res += [b[index_b]]
            index_b += 1
    return res


def sort_merge(lst):
    if len(lst) < 2: return lst
    middle = len(lst) // 2
    left = sort_merge(lst[:middle])
    right = sort_merge(lst[middle:])
    return merge_fix(left, right)


def sort_quick(lst):
    '''
    переписать эту функцию так
    чтобы не было три цикла
    за один цикл выбрать меньшие, большие и равные pivot
    '''
    if len(lst) < 2: return lst
    pivot = lst[0]
    left = list(filter(lambda x: x < pivot, lst))
    middle = list(filter(lambda x: x == pivot, lst))
    right = list(filter(lambda x: x > pivot, lst))
    return sort_quick(left) + middle + sort_quick(right)


def sort_quick_fix(lst):
    '''
    исправленная функция
    '''
    if len(lst) < 2: return lst
    pivot = lst[len(lst) // 2]
    left = []
    right = [] 
    middle = [lst[len(lst) // 2]]
    for i in range(1, len(lst)):
        if lst[i] < pivot: 
            left += [lst[i]]
        elif lst[i] > pivot: 
            right += [lst[i]]
        else: 
            middle += [lst[i]]
    return sort_quick_fix(left) + middle + sort_quick_fix(right)


def sort_heap():
    return