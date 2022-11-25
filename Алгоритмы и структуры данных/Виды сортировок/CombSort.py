from BubbleSort import bubble_sort


def comb_sort(lst):
    '''Сортировка расческой'''
    end = len(lst) - 1
    coefficient = 1.2473309
    step = end
    while step > 1:
        for i in range(end):
            if i + step > end:
                break
            if (lst[i] > lst[int(i + step)]):
                lst[i], lst[int(i+step)] = lst[int(i+step)], lst[i]
        step //= coefficient
    return bubble_sort(lst)
