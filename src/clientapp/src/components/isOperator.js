
export default function isOperator(token) {
    return token === '-' || token === '+' || token === '*' || token === '/' || token === 'SE' || token === 'SN';
}