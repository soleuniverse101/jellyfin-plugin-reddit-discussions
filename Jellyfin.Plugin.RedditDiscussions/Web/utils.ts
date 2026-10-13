export function waitFor(
  predicate: () => boolean,
  interval: number,
): Promise<void> {
  return new Promise((resolve) => {
    function checkPredicate() {
      if (predicate()) {
        resolve();
      } else {
        setTimeout(checkPredicate, interval);
      }
    }

    checkPredicate();
  });
}
