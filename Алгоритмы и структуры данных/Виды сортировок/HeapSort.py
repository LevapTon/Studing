def make_heap(lst, heap_size, root_index):
    largest = root_index
    left_child = (2 * root_index) + 1
    right_child = (2 * root_index) + 2
    if left_child < heap_size and lst[left_child] > lst[largest]:
        largest = left_child
    if right_child < heap_size and lst[right_child] > lst[largest]:
        largest = right_child
    if largest != root_index:
        lst[root_index], lst[largest] = lst[largest], lst[root_index]
        make_heap(lst, heap_size, largest)

def heap_sort(lst):
    '''Сортировка кучей (пирамидальная)'''
    n = len(lst)
    for i in range(n, -1, -1):
        make_heap(lst, n, i)
    for i in range(n - 1, 0, -1):
        lst[i], lst[0] = lst[0], lst[i]
        make_heap(lst, i, 0)
    return lst
