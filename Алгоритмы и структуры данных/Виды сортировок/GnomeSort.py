def gnome_sort(lst):
    '''Гномья сортировка'''
    i = 1
    while i < len(lst):
        if (i == 0 or lst[i - 1] <= lst[i]):
            i += 1
        else:
            lst[i], lst[i - 1] = lst[i - 1], lst[i]
            i -= 1
    return lst
