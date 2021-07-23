import isOperator from './isOperator';

export default function format(input) {
  if (isOperator(input)) {
    return input;
  } else {
    return input.replace('.', ',');
  }
}