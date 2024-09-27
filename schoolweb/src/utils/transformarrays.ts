interface InputItem {
  [key: string]: any;
  id: number;
}

interface OutputItem {
  label: string;
  value: number;
}

export function transformArray<T extends InputItem>(
  inputArray: T[],
  labelKey: keyof T,
  valueKey: keyof T = 'id'
): OutputItem[] {
  return inputArray.map((item) => ({
    label: String(item[labelKey]),
    value: Number(item[valueKey]),
  }));
}

// // Example usage
// const input = [{ id: 1, name: "grade 4", desc: "", schoolId: 2 }];
// const result = transformArray(input, 'name');
// console.log(result);

// // Another example with different keys
// const anotherInput = [{ userId: 5, username: "john_doe", age: 30 }];
// const anotherResult = transformArray(anotherInput, 'username', 'userId');
// console.log(anotherResult);
