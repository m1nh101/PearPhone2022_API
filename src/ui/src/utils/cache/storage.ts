const ls = localStorage;

export const set = (key: string, value: any) => ls.setItem(key, value);

export const get = (key: string) => ls.getItem(key);

export const remove = (key: string) => ls.removeItem(key);
export const removeALL = () => ls.clear();
