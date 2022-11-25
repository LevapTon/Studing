def bubble_sort(lst):
    '''Пузырьковая сортировка'''
    end = len(lst) - 1
    flag = True
    while flag:
        flag = False
        for i in range(0, end, 1):
            if (lst[i] > lst[i+1]):
                lst[i], lst[i+1] = lst[i+1], lst[i]
                flag = True
        end -= 1
    return lst
