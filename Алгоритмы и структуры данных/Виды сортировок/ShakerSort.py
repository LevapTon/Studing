def shaker_sort(lst):
    '''Шейкерная сортировка'''
    flag = True
    beg = 0
    end = len(lst) - 1
    while flag:
        flag = False
        for i in range(beg, end, 1):
            if (lst[i] > lst[i+1]):
                lst[i], lst[i+1] = lst[i+1], lst[i]
                flag = True
        if not flag:
            break
        end -= 1
        for i in range(end, beg, -1):
            if (lst[i] < lst[i-1]):
                lst[i], lst[i-1] = lst[i-1], lst[i]
                flag = True
        beg += 1
    return lst
