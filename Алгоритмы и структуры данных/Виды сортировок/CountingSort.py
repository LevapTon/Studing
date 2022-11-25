def counting_sort(inputArray):
    '''Сортировка подсчетом'''
    maxEl = inputArray[0]
    for elem in inputArray:
        if elem > maxEl:
            maxEl = elem
    countArrayLength = maxEl+1 
    countArray = [0] * countArrayLength 
    for el in inputArray: 
        countArray[el] += 1 
    for i in range(1, countArrayLength): 
        countArray[i] += countArray[i-1] 
    outputArray = [0] * len(inputArray) 
    i = len(inputArray) - 1 
    while i >= 0: 
        currentEl = inputArray[i] 
        countArray[currentEl] -= 1 
        newPosition = countArray[currentEl] 
        outputArray[newPosition] = currentEl 
        i -= 1 
    return outputArray 
