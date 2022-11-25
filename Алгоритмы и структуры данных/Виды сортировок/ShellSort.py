def shell_sort (lst):
    '''Сортировка Шелла'''
    end = len(lst) - 1
    step = end // 2
    while step >= 1:
        for i in range(end):
            if i + step > end:
                break
            j = i
            diff = int(j - step)
            while (diff >= 0 and lst[diff] > lst[j]):
                lst[diff], lst[j] = lst[j], lst[diff]
                j = diff
                diff = j - step
        step //= 2
    return lst
