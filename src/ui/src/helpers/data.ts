export interface data {
  title: string;
  description: string;
  img: string;
  color: string;
  path: string;
}
export interface Policy {
  name: string;
  description: string;
  icon: string;
}
export interface Product {
  title: string;
  price: string;
  image01: string;
  image02: string;
  categorySlug: string;
  colors: string[];
  slug: string;
  size: string[];
  description: string;
}
export interface Category {
  display: string;
  categorySlug: string;
}
export interface Color {
  display: string;
  color: string;
}
export interface Size {
  display: string;
  size: string;
}
