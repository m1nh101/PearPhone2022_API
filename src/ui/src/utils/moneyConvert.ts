export const moneyUs = (num: string) =>
  Number(num).toLocaleString("en-US", { style: "currency", currency: "VND" });
export const moneyVi = (num: string) =>
  Number(num).toLocaleString("vi", { style: "currency", currency: "VND" });
// export default {
//   moneyUs,
//   moneyVi,
// };
