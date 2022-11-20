import Cookies from "js-cookie";

const ck = Cookies;

export const set = (key: string, value: any) => ck.set(key, value);

export const get = (key: string) => ck.get(key);

export const remove = (key: string) => ck.remove(key);
