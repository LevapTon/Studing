from timeit import default_timer as t
from random import randint, shuffle
from CombSort import comb_sort
from ShellSort import shell_sort
from GnomeSort import gnome_sort
from RadixSort import radix_sort
from CountingSort import counting_sort
from BucketSort import bucket_sort
from TimSort import tim_sort
from BubbleSort import bubble_sort
from InsertionSort import insertion_sort
from SelectionSort import selection_sort
from ShakerSort import shaker_sort
from QuickSort import quick_sort
from MergeSort import merge_sort
from HeapSort import heap_sort


count = 16000
lst = [randint(0, 1000) for _ in range(count)]
print(lst[:10])
start = t()
res = counting_sort(lst)
print(round(t() - start, 3))
print(res[:10])

shuffle(res)

print(lst[:10])
start = t()
res = quick_sort(lst)
print(round(t() - start, 3))
print(res[:10])

shuffle(lst)

print(lst[:10])
start = t()
selection_sort(lst)
print(round(t() - start, 3))
print(lst[:10])