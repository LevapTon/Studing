def counting_sort_for_radix(inputArray, placeValue): 
    countArray = [0] * 10 
    inputSize = len(inputArray) 
    for i in range(inputSize): 
        placeElement = (inputArray[i] // placeValue) % 10 
        countArray[placeElement] += 1 
    for i in range(1, 10): 
        countArray[i] += countArray[i-1] 
        outputArray = [0] * inputSize 
        i = inputSize - 1 
    while i >= 0: 
        currentEl = inputArray[i] 
        placeElement = (inputArray[i] // placeValue) % 10 
        countArray[placeElement] -= 1 
        newPosition = countArray[placeElement] 
        outputArray[newPosition] = currentEl 
        i -= 1 
    return outputArray 
 
def radix_sort(inputArray): 
    '''Сортировка по основанию'''
    maxEl = max(inputArray) 
    D = 1 
    while maxEl > 0: 
        maxEl /= 10 
        D += 1 
    placeVal = 1 
    outputArray = inputArray 
    while D > 0: 
        outputArray = counting_sort_for_radix(outputArray, placeVal) 
        placeVal *= 10 
        D -= 1 
    
    return outputArray 
